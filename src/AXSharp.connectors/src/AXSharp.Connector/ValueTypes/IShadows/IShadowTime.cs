// AXSharp.Connector
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/axsharp/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/axsharp/blob/dev/LICENSE
// Third party licenses: https://github.com/ix-ax/axsharp/blob/master/notices.md

using System;

namespace AXSharp.Connector.ValueTypes.Shadows;

/// <summary>
///     Defines contract to access shadow value of <see cref="TimeSpan" />; TIME type of the PLC.
/// </summary>
public interface IShadowTime : IShadow<TimeSpan>
{
}