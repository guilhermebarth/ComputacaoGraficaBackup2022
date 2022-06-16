using System;
using System.Collections.Generic;
using System.Text;
using CG_Biblioteca;
using gcgcg;
using OpenTK.Graphics.OpenGL;

namespace CG_N2
{
    class Circulo : ObjetoGeometria
    {
        public Circulo(string rotulo, Objeto paiRef, Ponto4D pontoCentral, int raioCirculo) : base(rotulo, paiRef)
        {
            PrimitivaTipo = PrimitiveType.Points;
            GerarPontos(pontoCentral, raioCirculo);
        }

        private void GerarPontos(Ponto4D pontoCentral, int raioCirculo)
        {
            for (var i = 0; i < 72; i++)
            {
                var pontoMatematico = Matematica.GerarPtosCirculo(i * 5, raioCirculo);
                var pontoFinal = new Ponto4D(pontoMatematico.X + pontoCentral.X, pontoMatematico.Y + pontoCentral.Y, 0);
                PontosAdicionar(pontoFinal);
            }
        }

        protected override void DesenharObjeto()
        {
            GL.Color3(ObjetoCor.CorR, ObjetoCor.CorG, ObjetoCor.CorB);
            GL.Begin(PrimitivaTipo);
            foreach (Ponto4D pto in pontosLista)
            {
                GL.Vertex2(pto.X, pto.Y);
            }
            GL.End();
        }
    }
}
