using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AppHotel.Model
{
    public class Hospedagem
    {
        int qtd_adultos;
        Suite quarto_escolhido;

        public Suite QuartoEscolhido
        {
            get => quarto_escolhido;
            set
            {
                if (value == null)
                    throw new Exception("Por favor, selecione sua acomodação!");

                quarto_escolhido = value;
            }
        }

        public int QtdAdultos
        {
            get => qtd_adultos;

            set
            {
                if (value == 0)
                    throw new Exception("Por favor, selecione a quantidade de adultos!");

                qtd_adultos = value;
            }
        }

        public int QtdCriancas { get; set; }
        public DateTime DataCheckin { get; set; }
        public DateTime DataCheckout { get; set; }

        public int Estadia
        {
            get
            {
                return DataCheckout.Subtract(DataCheckin).Days;
            }
        }

        public double ValorTotal
        {
            get => ( (QtdAdultos * QuartoEscolhido.DiariaAdulto) + 
                (QtdCriancas * QuartoEscolhido.DiariaCrianca) ) * Estadia;
        }

    }
}