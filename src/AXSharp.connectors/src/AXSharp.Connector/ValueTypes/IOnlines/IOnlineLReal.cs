﻿// AXSharp.Connector
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/axsharp/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/axsharp/blob/dev/LICENSE
// Third party licenses: https://github.com/ix-ax/axsharp/blob/master/notices.md

namespace AXSharp.Connector.ValueTypes.Online;

/// <summary>
///     Defines contract to access online value of <see cref="double" />; LREAL type of the PLC.
/// </summary>
public interface IOnlineLReal : IOnline<double>
{
}