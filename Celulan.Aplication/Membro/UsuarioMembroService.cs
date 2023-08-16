using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Celulan.Repository;
using Celulan.Repository.Models;

namespace Celulan.Aplication.Membro
{
    public class UsuarioMembroService
    {
        private readonly CelulaContext _context;

        public UsuarioMembroService(CelulaContext context)
        {
            _context = context;
        }

        public bool CadastrarMembro(int id, UsuarioMembroRequest request)
        {
            try
            {
                var usuarioExiste = _context.Membros.FirstOrDefault(x => x.Email == request.Email);
                if (usuarioExiste == null)
                {
                    var Membro = new TabMembro()
                    {

                        Nome = request.Nome,
                        Email = request.Email,
                        Telefone = request.Telefone,
                        Cep = request.Cep,
                        Rua = request.Rua,
                        Numero = request.Numero,
                        Bairro = request.Bairro,
                        Cidade = request.Cidade,
                    };
                    _context.Membros.Add(Membro);
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

        public List<TabMembro> ObterMembros()
        {
            try
            {
                var membros = _context.Membros.ToList();
                return membros;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TabMembro ObterMembro(int id)
        {
            try
            {
                var membro = _context.Membros.FirstOrDefault(x => x.id == id);
                return membro;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AtualizarMembro(int id, UsuarioMembroRequest request)
        {
            try
            {
                var usuarioDb = _context.Membros.FirstOrDefault(x => x.id == id);
                if (usuarioDb == null) return false;

                usuarioDb.Nome = request.Nome;
                usuarioDb.Email = request.Email;
                usuarioDb.Telefone = request.Telefone;
                usuarioDb.Rua = request.Rua;
                usuarioDb.Numero = request.Numero;
                usuarioDb.Bairro = request.Bairro;
                usuarioDb.Cidade = request.Cidade;              
                
                _context.Membros.Update(usuarioDb);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool RemoverMembro(int id)
        {
            try
            {
                var membroDb = _context.Membros.FirstOrDefault(x => x.id == id);
                if (membroDb == null)
                    return false;

                _context.Membros.Remove(membroDb);
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

