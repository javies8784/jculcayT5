using jculcayS5.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> people = App.personRepo.GetAllPeople();
        listaPersona.ItemsSource = people;

    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.personRepo.UpdatePerson(txtName.Text);
        lblStatus.Text = App.personRepo.StatusMessage;

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {

    }

    private void bntActualizarCV_Clicked(object sender, EventArgs e)
    {

    }
}