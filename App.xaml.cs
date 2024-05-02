namespace jculcayS5;

public partial class App : Application
{
	public static PersoRepository personRepo { get; set; }
	public App(PersoRepository persoRepository)
	{
		InitializeComponent();

		MainPage = new Views.Vpersona();
		personRepo = persoRepository;


    }
}
