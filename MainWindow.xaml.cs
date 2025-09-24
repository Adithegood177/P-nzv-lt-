using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pénzváltó
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// Egy TextBox-ba beírod a forint összeget.

	/* ComboBox-ban kiválasztod a valutát(pl.EUR, USD, GBP).

	„Átváltás” gomb → kiírja az összeget a másik TextBlock-ba.

	„Törlés” gomb → kiüríti a mezőt.

	CheckBox: „Átváltás fordítva” → valutából forintba.

	Plusz feladat:

	Fordított átváltás

	Ha CheckBox be van jelölve → valutából váltson forintra.

	Példa: 100 EUR → 40 000 Ft.

	Több valutát is számoljon egyszerre

	Egy gombnyomásra ne csak a kiválasztott valutát írja ki, hanem az összeset.

	Példa: 10 000 Ft = 25 EUR, 27 USD, 22 GBP.

	Átváltási díj bevezetése

	CheckBox: „Kezelési díj 5%”.

	Ha be van jelölve, a számolásnál vonja le az 5%-ot.

	Példa: 100 EUR helyett csak 95 EUR.

	Érvényes bevitel ellenőrzése

	Ha nem számot írnak a TextBox-ba, dobjon MessageBox figyelmeztetést: „Adj meg számot!”.

	Törlés gomb

	Egyetlen gombnyomással törölje ki a beírt összeget és az eredményt.

	Eddigi átváltások listája

	Minden átváltás kerüljön bele egy ListBox-ba.

	Példa:

	1000 Ft → 2.5 EUR

	5000 Ft → 12.5 EUR

	Billentyű rövidítések

	Enter → átváltás

	Esc → mező törlése*/

	public partial class MainWindow : Window
	{
		private bool forditott = false;
		public MainWindow()
		{
			InitializeComponent();
			if (ValutaValasztas.Items.Count > 0) { (ValutaValasztas.Items[0] as ComboBoxItem)!.IsSelected = true; }


		}

		private void beirhatoOsszeg_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void AtvaltasClick(object sender, RoutedEventArgs e)
		{
			if (forditott == false)
			{
				if (ValutaValasztas.SelectedItem is ComboBoxItem item)
				{
					var valuta = double.Parse(item.Tag.ToString());
					var ertek = double.Parse(beirhatoOsszeg.Text)!;

					double atvaltottErtek = valuta * ertek;
					Eredmeny.Text = $"{atvaltottErtek:F0}";
				}

			}
			else
			{
				if (ValutaValasztas.SelectedItem is ComboBoxItem item)
				{
					var valuta = double.Parse(item.Tag.ToString());
					var ertek = double.Parse(beirhatoOsszeg.Text)!;

					double atvaltottErtek = ertek / valuta;
					Eredmeny.Text = $"{atvaltottErtek:F0}";



				}




			}
		}

		private void ValtasFordito_Checked(object sender, RoutedEventArgs e)
		{
			forditott = true;
		}

		private void ValtasFordito_Unchecked(object sender, RoutedEventArgs e)
		{
			forditott = false;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Eredmeny.Text = "";
			beirhatoOsszeg.Text = "";
		}
	}
}