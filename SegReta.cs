using CG_Biblioteca;
using gcgcg;
using OpenTK.Graphics.OpenGL;

namespace CG_N2
{
    internal class SegReta : ObjetoGeometria
    {
        private Ponto4D pontoCentral { get; set; }
        private Ponto4D pontoFinal { get; set; }

        public SegReta(string rotulo, Objeto paiRef, Ponto4D pontoCentral, Ponto4D pontoFinal) : base(rotulo, paiRef)
        {
            PrimitivaTipo = PrimitiveType.Lines;
            this.pontoCentral = pontoCentral;
            this.pontoFinal = pontoFinal;
        }

        protected override void DesenharObjeto()
        {
            GL.Color3(ObjetoCor.CorR, ObjetoCor.CorG, ObjetoCor.CorB);
            GL.Begin(PrimitivaTipo);
            {
                GL.Vertex2(pontoCentral.X, pontoCentral.Y);
                GL.Vertex2(pontoFinal.X, pontoFinal.Y);
            }
            GL.End();
        }
    }
}
