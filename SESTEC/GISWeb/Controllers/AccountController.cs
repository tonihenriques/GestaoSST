using BotDetect.Web.Mvc;
using GISCore.Business.Abstract;
using GISCore.Infrastructure.Utils;
using GISModel.DTO.Conta;
using GISWeb.Infraestrutura.Filters;
using GISWeb.Infraestrutura.Provider.Abstract;
using Ninject;
using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Web.UI;

namespace GISWeb.Controllers
{

    [SessionState(SessionStateBehavior.ReadOnly)]
    public class AccountController : BaseController
    {

        #region Inject

            [Inject]
            public ICustomAuthorizationProvider AutorizacaoProvider { get; set; }

            [Inject]
            public IUsuarioBusiness UsuarioBusiness { get; set; }

        #endregion

        public ActionResult Login(string path)
        {
            ViewBag.OcultarMenus = true;
            ViewBag.IncluirCaptcha = Convert.ToBoolean(ConfigurationManager.AppSettings["AD:DMZ"]);
            ViewBag.UrlAnterior = path;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AutenticacaoModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var cookieKey in Request.Cookies.AllKeys.Where(c => !c.Equals("__RequestVerificationToken")))
                    {
                        var deleteCookie = new HttpCookie(cookieKey);
                        deleteCookie.Expires = DateTime.Now;
                        Response.Cookies.Add(deleteCookie);
                    }

                    AutorizacaoProvider.Logar(usuario);

                    if (!string.IsNullOrWhiteSpace(usuario.Nome))
                        return Json(new { url = usuario.Nome.Replace("$", "&") });
                    else
                        return Json(new { url = Url.Action(ConfigurationManager.AppSettings["Web:DefaultAction"], ConfigurationManager.AppSettings["Web:DefaultController"]) });
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                return Json(new { alerta = ex.Message, titulo = "Oops! Problema ao realizar login..." });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "LoginCaptcha", "Código do CAPTCHA incorreto.")]
        public ActionResult LoginComCaptcha(AutenticacaoModel usuario)
        {
            MvcCaptcha.ResetCaptcha("LoginCaptcha");
            ViewBag.IncluirCaptcha = Convert.ToBoolean(ConfigurationManager.AppSettings["AD:DMZ"]);

            try
            {
                if (ModelState.IsValid)
                {
                    AutorizacaoProvider.Logar(usuario);

                    if (!string.IsNullOrWhiteSpace(usuario.Nome))
                        return Json(new { url = usuario.Nome.Replace("$", "&") });
                    else
                        return Json(new { url = Url.Action(ConfigurationManager.AppSettings["Web:DefaultAction"], ConfigurationManager.AppSettings["Web:DefaultController"]) });
                }

                return View("Login", usuario);
            }
            catch (Exception ex)
            {
                return Json(new { alerta = ex.Message, titulo = "Oops! Problema ao realizar login..." });
            }
        }

        public ActionResult Logout()
        {
            AutorizacaoProvider.Deslogar();

            foreach (var cookieKey in Request.Cookies.AllKeys)
            {
                var deleteCookie = new HttpCookie(cookieKey);
                deleteCookie.Expires = DateTime.Now;
                Response.Cookies.Add(deleteCookie);
            }

            return RedirectToAction("Login", "Account");
        }

        [Autorizador]
        [DadosUsuario]
        public ActionResult Perfil()
        {
            return View(AutorizacaoProvider.UsuarioAutenticado);
        }

        [HttpPost]
        [Autorizador]
        [DadosUsuario]
        public ActionResult AtualizarFoto(string imagemStringBase64)
        {
            try
            {
                UsuarioBusiness.SalvarAvatar(AutorizacaoProvider.UsuarioAutenticado.Login, imagemStringBase64, "jpg");
            }
            catch (Exception ex)
            {
                Extensions.GravaCookie("MensagemErro", ex.Message, 2);
            }

            return Json(new { url = Url.Action("Perfil") });
        }

        [OutputCache(Duration = 604800, Location = OutputCacheLocation.Client, VaryByParam = "login")]
        public ActionResult FotoPerfil(string login)
        {
            byte[] avatar = null;

            try
            {
                avatar = UsuarioBusiness.RecuperarAvatar(login);
            }
            catch { }

            if (avatar == null || avatar.Length == 0)
                avatar = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/Ace/avatars/unknown.png"));

            return File(avatar, "image/jpeg");
        }

    }
}