using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Avalonia.Controls;
using AvaloniaApplication6.Models;
using Microsoft.CodeAnalysis.Emit;
using Npgsql;

namespace AvaloniaApplication6;

public partial class MainWindow : Window
{
    private BindingList<Person> _persons;
    private string connectstring = "Host=localhost;Username=postgres;Password=admin;Database=postgres";
    
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void TopLevel_OnOpened(object? sender, EventArgs e)
    {
        _persons = new BindingList<Person>()
        {
        };
        
        var conn = new NpgsqlConnection(connectstring);
        conn.Open();
        var cmd = new NpgsqlCommand("SELECT * FROM workers", conn);
        NpgsqlDataReader reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            _persons.Add(new Person()
            {
                Fio = reader[0].ToString(), 
                Dolzh = reader[1].ToString(), 
                Podr = reader[2].ToString(), 
                Status = true
            });
        }
        
        PersonsList.Items = _persons;
    }
}