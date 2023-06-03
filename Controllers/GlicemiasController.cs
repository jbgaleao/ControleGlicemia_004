using AutoMapper;

using ControleGlicemia_002.Context;
using ControleGlicemia_002.Models;
using ControleGlicemia_002.ViewModel;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleGlicemia_002.Controllers
{
    public class GlicemiasController : Controller
    {
        private readonly GlicemiaContext _context;
        private readonly IMapper _mapper;

        public GlicemiasController(GlicemiaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<GlicemiaViewModel> listaGlicemiasVM = new();
            //List<Glicemia> listaFiltrada = AplicarFiltroGlicemia(_context.GLICEMIAS.ToList(), condicao);
            foreach (Glicemia? g in _context.GLICEMIAS.ToList())
            {
                GlicemiaViewModel gVM = _mapper.Map<GlicemiaViewModel>(g);
                listaGlicemiasVM.Add(gVM);
            }
            return View(listaGlicemiasVM);
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(GlicemiaViewModel gVM)
        {
            if (ModelState.IsValid)
            {
                Glicemia g = _mapper.Map<Glicemia>(gVM);
                await _context.AddAsync(g);
                // gVM.EhErro = "N";
                await _context.SaveChangesAsync();
                ViewBag.MessageFormularioOK = "Formulário criado com sucesso!";
            }
            else
            {
                ViewBag.MessageFormularioErro = "Foram encontrados erros no formulário. Favor verificar os campos preenchidos.";
                // gVM.EhErro = "S";
                // gVM.MensagemRetorno = "";
            }
            return View(gVM);
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null || _context.GLICEMIAS == null)
            {
                return NotFound();
            }

            Glicemia? g = await _context.GLICEMIAS.FindAsync(id);
            if (g == null)
            {
                return NotFound();
            }
            else
            {
                GlicemiaViewModel gVM = _mapper.Map<GlicemiaViewModel>(g);
                return View(gVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.GLICEMIAS == null)
            {
                return NotFound();
            }

            Glicemia? g = await _context.GLICEMIAS.FindAsync(id);
            if (g == null)
            {
                return NotFound();
            }
            else
            {
                GlicemiaViewModel gVM = _mapper.Map<GlicemiaViewModel>(g);
                return View(gVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("GlicemiaID,GlicemiaMedida,DataMedicao,HoraMedicao,DataAplicacao,HoraAplicacao,DoseRegular,DoseAjuste,Observacao")] GlicemiaViewModel gVM)
        {

            if (id != gVM.GlicemiaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Glicemia g = _mapper.Map<Glicemia>(gVM);
                    _context.Update(g);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Glicemia(gVM.GlicemiaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gVM);
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null || _context.GLICEMIAS == null)
            {
                return NotFound();
            }

            Glicemia? g = await _context.GLICEMIAS.FirstOrDefaultAsync(m => m.GlicemiaID == id);
            if (g == null)
            {
                return NotFound();
            }
            else
            {
                GlicemiaViewModel gVM = _mapper.Map<GlicemiaViewModel>(g);
                return View(gVM);
            }


        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int GlicemiaID)
        {
            if (_context.GLICEMIAS == null)
            {
                return Problem("Entity set 'GlicemiaContext.Glicemia'  is null.");
            }
            Glicemia? g = await _context.GLICEMIAS.FindAsync(GlicemiaID);
            if (g != null)
            {
                _context.GLICEMIAS.Remove(g);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Glicemia(int id)
        {
            return (_context.GLICEMIAS?.Any(e => e.GlicemiaID == id)).GetValueOrDefault();
        }
    }

}
