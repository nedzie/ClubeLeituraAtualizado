﻿using ClubeLeitura.ConsoleApp.Compartilhado;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.ModuloReserva
{
    public class RepositorioReserva : RepositorioBase<Reserva>
    {
        public RepositorioReserva()
        {
        }

        public override string Inserir(Reserva reserva)
        {
            reserva.numero = ++contadorNumero;

            reserva.Abrir();

            registros.Add(reserva);

            return "REGISTRO_VALIDO";
        }

        public Reserva[] SelecionarReservasEmAberto()
        {
            return registros.FindAll(x => x.estaAberta).ToArray();
        }
    }
}
