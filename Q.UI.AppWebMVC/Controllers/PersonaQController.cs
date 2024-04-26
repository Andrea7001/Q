using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q.EntidadesNegocio.EN;
using Q.LogicaDeNegocio.BL;

namespace Q.UI.AppWebMVC.Controllers
{
    public class PersonaQController : Controller
    {
        // GET: PersonaQController
        public async Task< ActionResult> Index()
        {
            var roles = await PersonaQBL.GetAll();
            return View(roles);
        }

        // GET: PersonaQController/Details/5
        public async Task <ActionResult> Details(int ID)
        {
            var result = await PersonaQBL.GetById(new PersonaQ { ID = ID });

            return View(result);
        }

        // GET: PersonaQController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonaQController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PersonaQ pRole)
        {
            try
            {
                if (ModelState.IsValid) // Verifica si los datos ingresados son válidos según las reglas de validación del modelo
                {
                    // Llama a tu capa de lógica de negocios para crear el nuevo usuario
                    var result = await PersonaQBL.Create(pRole);

                    if (result > 0) // Comprueba si la operación de creación fue exitosa
                    {
                        // Redirige al usuario a la acción Index si la creación fue exitosa
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error al crear el usuario."); // Agrega un error al ModelState si la creación falló
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el usuario: " + ex.Message);

                // Acceder a la excepción interna (inner exception) para obtener más detalles sobre el error
                if (ex.InnerException != null)
                {
                    ModelState.AddModelError("", "Detalles del error: " + ex.InnerException.Message);
                }
            }

            return View(pRole);

        }

        // GET: PersonaQController/Edit/5
        public async Task<ActionResult> Edit(int ID)
        {
            var result = await PersonaQBL.GetById(new PersonaQ { ID= ID});
            return View(result);
        }

        // POST: PersonaQController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PersonaQ personaQ)
        {
            try
            {
                var result = await PersonaQBL.Update(personaQ);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaQController/Delete/5
        public async Task <ActionResult> Delete(int ID)
        {
            var result = await PersonaQBL.GetById(new PersonaQ { ID = ID });
            return View(result);
        }

        // POST: PersonaQController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Delete(int ID,PersonaQ pRole)
        {
            try
            {
                var result = await PersonaQBL.Delete(pRole);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
