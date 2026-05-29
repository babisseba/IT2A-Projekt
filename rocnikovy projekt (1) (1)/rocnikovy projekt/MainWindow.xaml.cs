using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace rocnikovy_projekt
{
    public partial class MainWindow : Window
    {
        List<string> inventar = new List<string>();

        bool hlidacOdlakan = false;
        bool prozkoumalPlakat = false;
        bool prozkoumalPolstar = false;
        bool pavoukOdhalen = false;
        bool vranaOdlakana = false;
        bool skrinPromazana = false;
        bool proudVypnut = false;
        bool kamenVypacen = false;
        bool poklopOtevren = false;

        bool policieOdlakana = false;
        bool vzalKlicky = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartHry_Click(object sender, RoutedEventArgs e)
        {
            MenuScene.Visibility = Visibility.Collapsed;
            CelaScene.Visibility = Visibility.Visible;
            HerniUI.Visibility = Visibility.Visible;
            DialogText.Text = "Další otravný den. Musím odsud zmizet. Na nic nezapomeň.";
            DialogBox.Visibility = Visibility.Visible;
        }

        private void Konec_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ZpetMenu_Click(object sender, RoutedEventArgs e)
        {
            Restart_Click(null, null);
        }

        private void JitKBrane_Click(object sender, RoutedEventArgs e)
        {
            if (!proudVypnut)
            {
                UkazGameOver("Šel jsi přímo do světla reflektorů. Hlídač tě okamžitě zpozoroval oknem a smečka psů tě roztrhala.");
            }
            else
            {
                BranaScene.Visibility = Visibility.Collapsed;
                KanalScene.Visibility = Visibility.Visible;
                DialogBox.Visibility = Visibility.Collapsed;
            }
        }

        private void JitKeKanalu_Click(object sender, RoutedEventArgs e)
        {
            KanalScene.Visibility = Visibility.Collapsed;
            BranaScene.Visibility = Visibility.Visible;
            DialogBox.Visibility = Visibility.Collapsed;
        }

        private void UkazGameOver(string duvodSmrti)
        {
            CelaScene.Visibility = Visibility.Collapsed;
            BranaScene.Visibility = Visibility.Collapsed;
            KanalScene.Visibility = Visibility.Collapsed;
            HraniceScene.Visibility = Visibility.Collapsed;
            StokaScene.Visibility = Visibility.Collapsed;
            LesScene.Visibility = Visibility.Collapsed;
            AutoScene.Visibility = Visibility.Collapsed;
            MestoScene.Visibility = Visibility.Collapsed;
            PredsinScene.Visibility = Visibility.Collapsed;
            HerniUI.Visibility = Visibility.Collapsed;
            DialogBox.Visibility = Visibility.Collapsed;

            GameOverScene.Visibility = Visibility.Visible;
            GameOverText.Text = duvodSmrti;
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            inventar.Clear();
            InventoryPanel.Children.Clear();

            prozkoumalPlakat = false;
            prozkoumalPolstar = false;
            pavoukOdhalen = false;
            hlidacOdlakan = false;
            vranaOdlakana = false;
            skrinPromazana = false;
            proudVypnut = false;
            kamenVypacen = false;
            poklopOtevren = false;
            policieOdlakana = false;
            vzalKlicky = false;

            Lano.Visibility = Visibility.Visible;
            Miska.Visibility = Visibility.Visible;
            Mince.Visibility = Visibility.Visible;
            HasakBrana.Visibility = Visibility.Visible;
            OlejnickaBrana.Visibility = Visibility.Visible;
            Kamen.Visibility = Visibility.Visible;
            Drat.Visibility = Visibility.Visible;
            AKlicky.Visibility = Visibility.Visible;

            StokaScene.Visibility = Visibility.Collapsed;
            HraniceScene.Visibility = Visibility.Collapsed;
            LesScene.Visibility = Visibility.Collapsed;
            AutoScene.Visibility = Visibility.Collapsed;
            MestoScene.Visibility = Visibility.Collapsed;
            PredsinScene.Visibility = Visibility.Collapsed;
            VyhraAutoScene.Visibility = Visibility.Collapsed;
            VyhraNakladakScene.Visibility = Visibility.Collapsed;

            PozadiKanalu.Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri("pack://application:,,,/images/ven1_zhasnuto.png", System.UriKind.Absolute));
            PozadiCely.Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri("/images/cela_spinava.png", System.UriKind.Relative));
            PozadiBrany.Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri("pack://application:,,,/images/brana_roznuto.png", System.UriKind.Absolute));

            GameOverScene.Visibility = Visibility.Collapsed;
            CelaScene.Visibility = Visibility.Collapsed;
            KanalScene.Visibility = Visibility.Collapsed;
            BranaScene.Visibility = Visibility.Collapsed;
            MenuScene.Visibility = Visibility.Visible;
            HerniUI.Visibility = Visibility.Collapsed;
        }

        private void Navigace_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            HraniceScene.Visibility = Visibility.Collapsed;
            DialogBox.Visibility = Visibility.Collapsed;

            if (btn.Name == "CestaLes") LesScene.Visibility = Visibility.Visible;
            else if (btn.Name == "CestaAuto") AutoScene.Visibility = Visibility.Visible;
            else if (btn.Name == "CestaMesto") MestoScene.Visibility = Visibility.Visible;
            else if (btn.Name == "ZpetPredsin")
            {
                PredsinScene.Visibility = Visibility.Collapsed;
                MestoScene.Visibility = Visibility.Visible;
            }
        }

        private void OnHotspotClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string buttonName = clickedButton.Name;
            string defaultText = clickedButton.Tag?.ToString();
            DialogBox.Visibility = Visibility.Visible;

            if (defaultText != null)
            {
                DialogText.Text = defaultText;
            }

            if (buttonName == "Lano" || buttonName == "HasakBrana" || buttonName == "OlejnickaBrana" || buttonName == "Mince" || buttonName == "Kamen" || buttonName == "Drat")
            {
                if (!inventar.Contains(buttonName))
                {
                    inventar.Add(buttonName);
                    PridejIkonuDoInventare(buttonName);
                    DialogText.Text = "Vzal jsi: " + buttonName;
                    clickedButton.Visibility = Visibility.Collapsed;
                }
            }
            else if (buttonName == "Miska")
            {
                if (!inventar.Contains("Vecere"))
                {
                    inventar.Add("Vecere");
                    PridejIkonuDoInventare("Vecere");
                    DialogText.Text = "Sebral jsi zbytky včerejší večeře. Kdo ví, koho s tím nakrmíš.";
                    clickedButton.Visibility = Visibility.Collapsed;
                }
            }
            else if (buttonName == "Plakat")
            {
                if (inventar.Contains("Hadr"))
                {
                    DialogText.Text = "Otřel jsi špínu z plakátu. Najednou to dává smysl! Marie na obrázku prstem ukazuje přímo na pavučinu v rohu!";
                    pavoukOdhalen = true;
                    PozadiCely.Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri("/images/cela_cista.png", System.UriKind.Relative));
                }
                else
                {
                    prozkoumalPlakat = true;
                    DialogText.Text = "Plakát s Marií. Je celý špinavý, ale dole je sotva čitelný nápis: 'Pravdu hledej tam, kde hlava tvrdě odpočívá.'";
                }
            }
            else if (buttonName == "Polstar")
            {
                if (prozkoumalPlakat && !prozkoumalPolstar)
                {
                    prozkoumalPolstar = true;
                    DialogText.Text = "Zvedl jsi ten nepohodlný polštář. Zespodu je vyryto: 'Špína skrývá tajemství. Umyj to!'";
                }
                else if (prozkoumalPolstar) { DialogText.Text = "Polštář na zemi jsi už prozkoumal. Musíš vyřešit hadanku"; }
                else { DialogText.Text = "Tvrdý obdélníkový polštář. Kdo na tomhle může spát?"; }
            }
            else if (buttonName == "Umyvadlo")
            {
                if (prozkoumalPolstar && !inventar.Contains("Hadr"))
                {
                    DialogText.Text = "V ucpaném odtoku jsi nahmatal kus látky. Vytáhl jsi smradlavý mokrý hadr. To by šlo použít!";
                    inventar.Add("Hadr");
                    PridejIkonuDoInventare("Hadr");
                }
                else if (inventar.Contains("Hadr")) { DialogText.Text = "Zrezivělé umyvadlo. Už jsem z něj vyšťoural hadr, víc tu není."; }
                else { DialogText.Text = "Zrezivělé umyvadlo. Je to hnusný z toho pít, ale co už"; }
            }
            else if (buttonName == "Pavouk")
            {
                if (inventar.Contains("Klic")) { DialogText.Text = "Karel spokojeně žvýká zbytek večeře. Nechám ho být."; }
                else if (pavoukOdhalen && inventar.Contains("Vecere"))
                {
                    DialogText.Text = "Položil jsi jídlo blízko pavučiny. Pavouk slezl dolů si pochutnat. V pavučině celou dobu visel malý klíček! Máš ho.";
                    inventar.Add("Klic");
                    PridejIkonuDoInventare("Klic");
                }
                else if (pavoukOdhalen && !inventar.Contains("Vecere"))
                {
                    UkazGameOver("Sáhl jsi na pavučinu holou rukou. Pavouk tě kousl. Byl prudce jedovatý a na místě jsi zemřel.");
                }
                else { DialogText.Text = "Můj jediný kámoš v cele i když mě moc nemusí a dělá na mě divné obličeje. Ahoj Karle"; }
            }
            else if (buttonName == "Skrinka")
            {
                if (inventar.Contains("Pilka")) { DialogText.Text = "Skříňka je prázdná."; }
                else if (inventar.Contains("Klic"))
                {
                    DialogText.Text = "Klíček pasuje! Odemkl jsi skříňku a uvnitř našel pilku na železo.";
                    inventar.Add("Pilka");
                    PridejIkonuDoInventare("Pilka");
                }
                else { DialogText.Text = "Plechová skříňka je zamčená pevným visacím zámkem. Bez klíče se tam nedostanu."; }
            }
            else if (buttonName == "Mrize")
            {
                if (inventar.Contains("Pilka") && inventar.Contains("Lano"))
                {
                    DialogText.Text = "Sakra, ty reflektory svítí jako kráva. Musím bejt opatrnej. Jestli si mě ten strážnej v budce všimne, jsem v háji. Musím je nějak zhasnout, abych se proplížil.";
                    CelaScene.Visibility = Visibility.Collapsed;
                    BranaScene.Visibility = Visibility.Visible;
                    inventar.Clear();
                    InventoryPanel.Children.Clear();
                }
                else if (inventar.Contains("Pilka") && !inventar.Contains("Lano"))
                {
                    UkazGameOver("Mříže jsi přeřezal, ale zapomněl sis v cele vzít lano. Skočil jsi dolů, rozplácl se na beton a zlámal si vaz.");
                }
                else { DialogText.Text = "Pevné mříže. Holýma rukama je neohnu, potřebuji něco ostrého na železo."; }
            }
            else if (buttonName == "Vrana")
            {
                if (inventar.Contains("Mince"))
                {
                    DialogText.Text = "Hodil jsi blýskavou minci stranou. Vrána po ní skočila a odletěla z plotu pryč.";
                    vranaOdlakana = true;
                }
                else { DialogText.Text = "Zlá vrána. Když se k ní přiblížím moc blízko, začne krákat. Musím ji něčím odlákat."; }
            }
            else if (buttonName == "Skrin")
            {
                if (!vranaOdlakana)
                {
                    UkazGameOver("Přiblížil ses ke skříni, ale vrána na plotě začala hlasitě krákat. Hlídač tě uviděl a zastřelil tě.");
                    return;
                }
                if (!inventar.Contains("OlejnickaBrana") && !inventar.Contains("HasakBrana"))
                {
                    DialogText.Text = "Vrána je sice pryč, ale panty jsou úplně zrezivělé a zámek nepustí. Holýma rukama s tím nehnu, musím se tu po něčem podívat.";
                }
                else if (inventar.Contains("OlejnickaBrana") && !skrinPromazana)
                {
                    DialogText.Text = "Promazal jsi zrezivělé panty skříně. Teď půjde odšroubovat potichu.";
                    skrinPromazana = true;
                }
                else if (inventar.Contains("HasakBrana") && !skrinPromazana)
                {
                    UkazGameOver("Zkusil jsi odšroubovat kryt hasákem nasucho. Skřípání kovu přivolalo hlídače.");
                }
                else if (inventar.Contains("HasakBrana") && skrinPromazana && !proudVypnut)
                {
                    DialogText.Text = "Hasákem jsi potichu vypáčil skříň a přerušil hlavní kabely. BUM! Světla zhasla! Hlídač vylezl potmě z budky hledat baterku. Cesta ke kanálu je volná!";
                    proudVypnut = true;
                    hlidacOdlakan = true;
                    PozadiBrany.Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri("pack://application:,,,/images/brana_zhasnuto.png", System.UriKind.Absolute));
                }
            }
            else if (buttonName == "Prasklina")
            {
                if (!vranaOdlakana) { UkazGameOver("Šel jsi k prasklině ve zdi, ale vrána tě prozradila krákáním. Byl jsi zastřelen."); }
                else { DialogText.Text = "Obyčejná prasklina ve zdi, nic zajímavého v ní nevidím."; }
            }
            else if (buttonName == "BudkaOKno")
            {
                UkazGameOver("Šel jsi přímo k budce. Hlídač tě viděl oknem a zastřelil tě.");
            }
            else if (buttonName == "Poklop")
            {
                if (poklopOtevren)
                {
                    DialogText.Text = "Skočil jsi do smradlavé stoky. Tunel se před tebou rozděluje na dvě cesty.";
                    KanalScene.Visibility = Visibility.Collapsed;
                    StokaScene.Visibility = Visibility.Visible;
                    inventar.Clear();
                    InventoryPanel.Children.Clear();
                }
                else if (inventar.Contains("OlejnickaBrana") && inventar.Contains("HasakBrana"))
                {
                    DialogText.Text = "Promazal jsi zrezivělé okraje poklopu olejničkou a pak ho hasákem s obrovskou námahou odklopil. Cesta ven je volná!";
                    poklopOtevren = true;
                    PozadiKanalu.Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri("pack://application:,,,/images/ven2_zhasnuto.png", System.UriKind.Absolute));
                }
                else if (inventar.Contains("HasakBrana")) { DialogText.Text = "Zkusil jsi to vypáčit hasákem, ale poklop je úplně přirezlý. Chtělo by to okraje něčím promazat, jinak to neutáhnu."; }
                else { DialogText.Text = "Zarezlý a extrémně těžký poklop od kanálu. Holýma rukama s ním ani nehnu."; }
            }
            else if (buttonName == "Cesta1_Freedom")
            {
                DialogText.Text = "Vylezl jsi z kanálu na čerstvý vzduch. Kam dál?";
                StokaScene.Visibility = Visibility.Collapsed;
                HraniceScene.Visibility = Visibility.Visible;
            }
            else if (buttonName == "Cesta2_Prison")
            {
                UkazGameOver("Vstoupil jsi na lákavě vypadající, čistší a lépe osvětlenou betonovou cestu. Bohužel vedla přímo do suterénu hlídací věže. Hlídači tě okamžitě uviděli a útěk skončil.");
            }
            else if (buttonName == "ZpetOdAuta")
            {
                UkazGameOver("Rozhodl ses vrátit ke kanálu, ale stráže už mezitím objevily tvůj únik a odřízly ti cestu. Útěk skončil.");
            }
            else if (buttonName == "MedvedSmrt")
            {
                UkazGameOver("Vstoupil jsi hlouběji do lesa, kde tě překvapil hladový medvěd. Neměl jsi šanci na útěk.");
            }
            else if (buttonName == "AutoZamek")
            {
                if (inventar.Contains("Kamen"))
                {
                    AutoScene.Visibility = Visibility.Collapsed;
                    HerniUI.Visibility = Visibility.Collapsed;
                    VyhraAutoScene.Visibility = Visibility.Visible;
                }
                else if (inventar.Contains("Drat"))
                {
                    DialogText.Text = "Zkoušíš zámek vypáčit drátem, ale ten se jen ohýbá a mechanismus drží. Ztratil jsi tím spoustu času!";
                }
                else
                {
                    DialogText.Text = "Auto je zamčené. Rozbít okno holou rukou nepůjde, potřebuji něco tvrdého na sklo.";
                }
            }
            else if (buttonName == "Nadrazi")
            {
                if (inventar.Contains("Kamen") && !policieOdlakana)
                {
                    policieOdlakana = true;
                    DialogText.Text = "Prásk! Hodil jsi kámen do výlohy nádraží a spustil se alarm. Policisté opustili své místo a běží to vyšetřit.";
                }
                else if (policieOdlakana) { DialogText.Text = "Alarm na nádraží stále řve a policie to tam prohledává. Tam teď nemůžu."; }
                else { UkazGameOver("Vydal ses na nádraží. Uviděly tě bezpečnostní kamery a hned v další stanici tě zatkla policie."); }
            }
            else if (buttonName == "Policiste")
            {
                if (policieOdlakana) { DialogText.Text = "Policisté teď běhají kolem nádraží a hledají pachatele. Nebudu je dráždit."; }
                else { UkazGameOver("Rozhodl ses jít k policistům a vzdát se. Skončil jsi zpátky v cele."); }
            }
            else if (buttonName == "ZamceneDvere")
            {
                if (inventar.Contains("Drat") && !vzalKlicky)
                {
                    MestoScene.Visibility = Visibility.Collapsed;
                    PredsinScene.Visibility = Visibility.Visible;
                    DialogText.Text = "Pomocí drátu jsi potichu vyháčkoval starý zámek a vešel dovnitř. Rychle najdi ty klíčky, ať nevzbudíš babičku!";
                }
                else if (vzalKlicky) { DialogText.Text = "Klíčky už mám. Znovu tam nepolezu, ať nevzbudím tu starou babičku."; }
                else { UkazGameOver("Zkusil jsi vzít za kliku, ale uvnitř byla stará babička, která začala hlasitě hulákat. Přivolala hlídku a policisté tě okamžitě zatkli."); }
            }
            else if (buttonName == "Nakladak")
            {
                if (policieOdlakana && vzalKlicky)
                {
                    MestoScene.Visibility = Visibility.Collapsed;
                    HerniUI.Visibility = Visibility.Collapsed;
                    VyhraNakladakScene.Visibility = Visibility.Visible;
                }
                else if (policieOdlakana && !vzalKlicky) { DialogText.Text = "Policie je sice pryč, ale náklaďák je zamčený a nemám ho jak nastartovat. Potřebuji zkusit najít klíčky."; }
                else if (!policieOdlakana && vzalKlicky) { DialogText.Text = "Mám sice klíčky, ale u náklaďáku pořád stojí policie. Musím je nějak odlákat, třeba velkým hlukem na druhé straně ulice."; }
                else { DialogText.Text = "Blízko náklaďáku stojí policie a navíc nemám klíčky. Musím se tu porozhlédnout."; }
            }
            else if (buttonName == "AKlicky")
            {
                if (!vzalKlicky)
                {
                    inventar.Add("Klicky");
                    PridejIkonuDoInventare("Klicky");
                    vzalKlicky = true;
                    clickedButton.Visibility = Visibility.Collapsed;
                    DialogText.Text = "Máš je! Sebral jsi klíčky od náklaďáku a tiše ses vrátil ven. Rychle pryč.";
                }
            }
        }

        private void PridejIkonuDoInventare(string nazevPredmetu)
        {
            TextBlock ikona = new TextBlock
            {
                Text = "[" + nazevPredmetu.ToUpper() + "] ",
                Foreground = Brushes.White,
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5),
                VerticalAlignment = VerticalAlignment.Center
            };
            InventoryPanel.Children.Add(ikona);
        }
    }
}