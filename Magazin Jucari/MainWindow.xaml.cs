using System.Windows;

namespace MagazinWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AfiseazaJucarie();
        }

        private void AfiseazaJucarie()
        {
            string nume = "Masinuta Ferrari";
            double pret = 149.99;
            string categorie = "Vehicule";
            int stoc = 25;

            lblNume.Content = $"Nume: {nume}";
            lblPret.Content = $"Pret: {pret:F2} lei";
            lblCategorie.Content = $"Categorie: {categorie}";
            lblStoc.Content = $"Stoc: {stoc} bucati";
        }
    }
}