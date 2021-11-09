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

namespace P2_AP1_Vismar_20190425.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cProyectos.xaml
    /// </summary>
    public partial class cProyectos : Window
    {
        public cProyectos()
        {
            InitializeComponent();
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Proyectos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:

                        if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.ProyectoId == Utilidades.ToInt(CriterioTextBox.Text) && e.Fecha.Date <= HastaDatePicker.SelectedDate && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else if (HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.ProyectoId == Utilidades.ToInt(CriterioTextBox.Text) && e.Fecha.Date <= HastaDatePicker.SelectedDate);
                        }
                        else if (DesdeDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.ProyectoId == Utilidades.ToInt(CriterioTextBox.Text) && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = ProyectosBLL.GetList(e => e.ProyectoId == Utilidades.ToInt(CriterioTextBox.Text));
                        }

                        break;
                    case 1:

                        if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.DescripcionProyecto.Contains(CriterioTextBox.Text.ToLower()) && e.Fecha.Date <= HastaDatePicker.SelectedDate && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else if (HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.DescripcionProyecto.Contains(CriterioTextBox.Text.ToLower()) && e.Fecha.Date <= HastaDatePicker.SelectedDate);
                        }
                        else if (DesdeDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.DescripcionProyecto.Contains(CriterioTextBox.Text.ToLower()) && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = ProyectosBLL.GetList(e => e.DescripcionProyecto.Contains(CriterioTextBox.Text.ToLower()));
                        }
                        break;

                    case 2:

                        if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.Total.Equals(int.Parse(CriterioTextBox.Text)) && e.Fecha.Date <= HastaDatePicker.SelectedDate && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else if (HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.Total.Equals(int.Parse(CriterioTextBox.Text)) && e.Fecha.Date <= HastaDatePicker.SelectedDate);
                        }
                        else if (DesdeDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.Total.Equals(int.Parse(CriterioTextBox.Text)) && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = ProyectosBLL.GetList(e => e.Total.Equals(int.Parse(CriterioTextBox.Text)));
                        }
                        break;
                }
            }
            else
            {
                listado = ProyectosBLL.GetList(e => true);
            }

            if (DesdeDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex < 0)
            {
                listado = ProyectosBLL.GetList(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate);
            }

            if (HastaDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex < 0)
            {
                listado = ProyectosBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);
            }

            if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex < 0)
            {
                listado = ProyectosBLL.GetList(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate && c.Fecha.Date <= HastaDatePicker.SelectedDate);
            }

            DatosDataGrid.ItemsSource = null;

            DatosDataGrid.ItemsSource = listado;
        }
    }
}
