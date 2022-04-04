﻿using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class MotoristaRepository : IMotoristaRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idMotorista, Motorista motoristaU)
        {
            Motorista motoristaBuscado = BuscarPorID(idMotorista);
            if (motoristaU.Cnh != null) { motoristaBuscado.Cnh = motoristaU.Cnh; }
            if(motoristaU.IdMotorista != null) { motoristaBuscado.IdMotorista = motoristaU.IdMotorista; }
            if(motoristaU.IdUsuario != null) { motoristaBuscado.IdUsuario = motoristaU.IdUsuario; }
            if(motoristaU.IdUsuarioNavigation != null) { motoristaBuscado.IdUsuarioNavigation = motoristaU.IdUsuarioNavigation; }
            if(motoristaU.Rota != null) { motoristaBuscado.Rota = motoristaU.Rota; }

            ctx.Motoristas.Update(motoristaBuscado);
            ctx.SaveChanges();
        }

        public Motorista BuscarPorID(int idMotorista)
        {
            return ctx.Motoristas.FirstOrDefault(c => c.IdMotorista == idMotorista);
        }

        public void Cadastrar(Motorista NovoMotorista)
        {
            if(NovoMotorista!= null)
            {
                ctx.Motoristas.Add(NovoMotorista);
            }
            ctx.SaveChanges();
        }

        public void Deletar(int idMotorista)
        {
            Motorista motoristaBuscado = BuscarPorID(idMotorista);

            ctx.Motoristas.Remove(motoristaBuscado);
            ctx.SaveChanges();
        }

        public List<Motorista> Listar()
        {
            return ctx.Motoristas.ToList();
        }
    }
}
