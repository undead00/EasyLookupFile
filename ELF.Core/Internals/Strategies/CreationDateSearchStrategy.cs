// Copyright (C) 2011 Alexis Kochetov.
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
using System;
using System.IO;
using ELF.Contracts;
using ELF.Contracts.Internals;

namespace ELF.Core.Internals.Strategies
{
  internal sealed class CreationDateSearchStrategy : ISearchStrategy
  {
    private readonly SearchCondition condition;
    private readonly DateTime value;

    public SearchCondition Condition
    {
      get { return condition; }
    }

    public DateTime Value
    {
      get { return value; }
    }

    public bool Match(FileInfo fileInfo)
    {
      return condition == SearchCondition.GreaterThanOrEqual
        ? fileInfo.CreationTime >= value
        : fileInfo.CreationTime <= value;
    }

    public CreationDateSearchStrategy(SearchCondition condition, DateTime value)
    {
      this.condition = condition;
      this.value = value;
    }
  }
}