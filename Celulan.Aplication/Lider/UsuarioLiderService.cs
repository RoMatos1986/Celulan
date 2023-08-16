using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Celulan.Aplication.Membro;
using Celulan.Repository.Models;
using Celulan.Repository;
using Microsoft.EntityFrameworkCore;

namespace Celulan.Aplication.Lider
{
    public class UsuarioLiderService
    {
        private readonly CelulaContext _context;

        public UsuarioLiderService(CelulaContext context)
        {
            _context = context;
        }
        public bool CadastrarLider(int id, UsuarioLiderRequest request)
        {
            try
            {
                var usuarioExiste = _context.Lideres.FirstOrDefault(x => x.Email == request.Email);
                if (usuarioExiste == null)
                {
                    var Lider = new TabLider()
                    {

                        Lider = request.Lider,
                        Email = request.Email,
                        Telefone = request.Telefone,
                        Celula = request.Celula,
                        Rua = request.Rua,
                        Numero = request.Numero,
                        Bairro = request.Bairro,
                        Cidade = request.Cidade,
                    };
                    _context.Lideres.Add(Lider);
                    _context.SaveChanges();
                    return true;

                }
                return false;



            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TabLider> ObterLideres()
        {
            try
            {
                var lider = _context.Lideres.ToList();
                return lider;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TabLider ObterLider(int id)
        {
            try
            {
                var Lider = _context.Lideres.FirstOrDefault(x => x.id == id);
                return Lider;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AtualizarLider(int id, UsuarioLiderRequest request)
        {
            try
            {
                var liderDb = _context.Lideres.FirstOrDefault(x => x.id == id);
                if (liderDb == null) return false;

                liderDb.Lider = request.Lider;
                liderDb.Email = request.Email;
                liderDb.Telefone = request.Telefone;
                liderDb.Rua = request.Rua;
                liderDb.Numero = request.Numero;
                liderDb.Bairro = request.Bairro;
                liderDb.Cidade = request.Cidade;

                _context.Lideres.Update(liderDb);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoverLider(int id)
        {
            try
            {
                var liderDb = _context.Lideres.FirstOrDefault(x => x.id == id);
                if (liderDb == null)
                    return false;

                _context.Lideres.Remove(liderDb);
                _context.SaveChanges();
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }
    } 
    

}

