using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace CookList.Views;

public class DishController
{
    private DishModel model;
    private MainWindow view;

    public DishController(DishModel model, MainWindow view)
    {
        this.model = model;
        this.view = view;
    }

    public void AddDish(string name, string ingrediens)
    {
        var newDish = new Dish
        {
            Id = model.GetDishs().Count + 1,
            Name = name,
            Ingredients = ingrediens
        };
        model.AddDish(newDish);
        LoadDishs();
    }

    public void RemoveDish(int id)
    {
        model.RemoveDish(id);
        LoadDishs();
    }

    public void LoadDishs()
    {
        if (view.DishListBox != null)
        {
            view.DishListBox.Items.Clear();
            foreach (var dish in model.GetDishs())
            {
                view.DishListBox.Items.Add($"{dish.Name} - {dish.Ingredients}");
            }
        }
    }
}

public partial class MainWindow : Window
{
    private DishController controller;

    public MainWindow()
    {
        InitializeComponent();
        var model = new DishModel();
        controller = new DishController(model, this);
        controller.LoadDishs();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        NameTextBox = this.FindControl<TextBox>("NameTextBox");
        IngredientsTextBox = this.FindControl<TextBox>("IngredientsTextBox");
        DishListBox = this.FindControl<ListBox>("DishListBox");
    }

    private void AddDish_Click(object sender, RoutedEventArgs e)
    {
        if (NameTextBox == null || IngredientsTextBox == null)
        {
            throw new Exception("NameTextBox or IngredientsTextBox is not initialized.");
        }

        controller.AddDish(NameTextBox.Text, IngredientsTextBox.Text);
        NameTextBox.Text = string.Empty;
        IngredientsTextBox.Text = string.Empty;
    }
    private void OnClearClick(object sender, RoutedEventArgs e)
    {
        var dish = this.FindControl<ListBox>("DishListBox");


        DishListBox.Items.Remove(DishListBox.SelectedItem);
    }
    

}

