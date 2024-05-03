using jculcayS5.Models;
using System.Collections.ObjectModel;

using System.ComponentModel;
using System.Xml.Linq;
using System.Windows.Input;

namespace jculcayS5.Views;

public partial class Vpersona : ContentPage
{

    public ObservableCollection<Persona> Data { get; set; }


    public Vpersona()
    {
        InitializeComponent();

    }


    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.personRepo.AddNewPerson(txtName.Text);
        lblStatus.Text = App.personRepo.StatusMessage;

        listar();

    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {

        listar();

    }

    public void listar()
    {
        // lblStatus.Text = "";
        List<Persona> people = App.personRepo.GetAllPeople();
        listaPersona.ItemsSource = people;
    }
    public void limpiar()
    {
        txtId.Text = "";
        txtName.Text = "";

    }



    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        if (!String.IsNullOrEmpty(txtId.Text))
        {
            App.personRepo.UpdatePerson(Int32.Parse(txtId.Text), txtName.Text);
            lblStatus.Text = App.personRepo.StatusMessage;
            listar();
            limpiar();

        }
        else
        {
            DisplayAlert("Alerta", "Tiene que seleccionar un registro para actualizar", "Cerrar");
        }

    }



    private void btnEliminar_Clicked(object sender, EventArgs e)
    {

        lblStatus.Text = "";
        if (!String.IsNullOrEmpty(txtId.Text))
        {
            App.personRepo.DeletePerson(Int32.Parse(txtId.Text));
            lblStatus.Text = App.personRepo.StatusMessage;
            listar();
            limpiar();

        }
        else
        {
            DisplayAlert("Alerta", "Tiene que seleccionar un registro para eliminar", "Cerrar");
        }
    }

    private void listaPersona_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var itemSelect = e.CurrentSelection[0] as Persona;
        if (itemSelect != null)
        {
            txtId.Text = itemSelect.Id.ToString();
            txtName.Text = itemSelect.Name.ToString();

            //DisplayAlert("Item Seleccionado", $"{itemSelect.Id}"+$"{itemSelect.Name}", "OK");
        }


    }

}