using P2_AP1_Vismar_20190425.BLL;
using P2_AP1_Vismar_20190425.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P2_AP1_Vismar_20190425.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProyectos.xaml
    /// </summary>
    public partial class rProyectos : Window
    {

        private Proyectos proyecto = new Proyectos();

        private ProyectosDetalle detalles = new ProyectosDetalle();

        public rProyectos()
        {
            InitializeComponent();
            this.DataContext = proyecto;

            TipoTareaComboBox.ItemsSource = TiposTareasBLL.GetTiposTarea();

            TipoTareaComboBox.SelectedValuePath = "TipoTareaId";

            TipoTareaComboBox.DisplayMemberPath = "DescripcionTipoTarea";

            TotalTextBox.Text = "0";
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = proyecto;
        }
        private void Limpiar()
        {
            this.proyecto = new Proyectos();

            this.DataContext = proyecto;
        }
        
        private bool ExisteEnLaBaseDeDatos()
        {
            Proyectos esValido = ProyectosBLL.Buscar(proyecto.ProyectoId);

            return (esValido != null);
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos encontrado = ProyectosBLL.Buscar(proyecto.ProyectoId);

            if (encontrado != null)
            {
                proyecto = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("El proyecto no se encuentra en la Base de Datos...", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
