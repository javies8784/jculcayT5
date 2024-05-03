using jculcayS5.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace jculcayS5.Views;

public partial class Vpersona : ContentPage
{

    public ObservableCollection<Persona> Data { get; set; }

    public ICommand RemoveEquipmentCommand => new Command<Persona>(ReMoveItem);

   //public ICommand AddItemCommand => new Command(AddItems);

    public Vpersona()
	{
		InitializeComponent();

	}

    private void ReMoveItem(Persona obj)
    {
        DisplayAlert("Alerta", "Seleccione un estudiante", "Cerrar");
        System.Diagnostics.Debug.WriteLine(" the selected item's name  is:  " + obj.Name);

        Data.Remove(obj);
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
        List<Persona> people = App.personRepo.GetAllPeople();
        listaPersona.ItemsSource = people;
    }
    public void limpiar() {
        txtId.Text = "";
        txtName.Text = "";

    }



    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        lblStatus.Text = App.personRepo.StatusMessage;
            listar();
            limpiar();

        }
        else {
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

    {
            txtId.Text = itemSelect.Id.ToString();
            txtName.Text = itemSelect.Name.ToString();

            //DisplayAlert("Item Seleccionado", $"{itemSelect.Id}"+$"{itemSelect.Name}", "OK");
        }

    }
}