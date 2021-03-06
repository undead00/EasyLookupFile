﻿// Copyright (C) 2011 Alexis Kochetov.
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// Created by: Alexis Kochetov
// Created:    2011.03.15
using System.ComponentModel.Composition;
using System.Windows.Controls;
using ELF.Contracts;

namespace ELF.Views
{
  /// <summary>
  /// Interaction logic for BasicView.xaml
  /// </summary>
  [Export]
  [Export("ELF.PluginContract", typeof(IPlugin))]
  [Plugin("Core", "Basic file search")]
  public partial class BasicView : UserControl, IPlugin
  {
    private SearchParameters parameters;

    public SearchParameters Parameters
    {
      get { return parameters ?? (parameters = new SearchParameters()); }
      set {
        if (value == null || parameters == value) 
          return;
        parameters = value;
        DataContext = Parameters;
      }
    }

    [Import("ELF.Core.CoreSearchStrategyFactory")]
    public ISearchStrategyFactory StrategyFactory
    {
      get; private set;
    }

    public BasicView()
    {
      InitializeComponent();
    }
  }
}
