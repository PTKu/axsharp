﻿// AXSharp.Connector.S71500.WebAPI
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/axsharp/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/axsharp/blob/dev/LICENSE
// Third party licenses: https://github.com/ix-ax/axsharp/blob/master/notices.md

using AXSharp.Connector.ValueTypes;

namespace AXSharp.Connector.S71500.WebApi;

/// <summary>
/// Represents wrapper for a PLC LREAL variable.
/// </summary>
public class WebApiLReal : OnlinerLReal, IWebApiPrimitive
{
    private readonly WebApiConnector _webApiConnector;

    /// <inheritdoc />
    public WebApiLReal()
    {
        _webApiConnector = new WebApiConnector();
    }


    /// <inheritdoc />
    public WebApiLReal(ITwinObject parent,
        string readableTail,
        string symbolTail)
        : base(parent,
            readableTail,
            symbolTail)
    {
        _webApiConnector = WebApiConnector.Cast(parent.GetConnector());
    }

    private ApiPlcWriteRequest? _plcWriteRequestData;
    private ApiPlcReadRequest? _plcReadRequestData;

    /// <inheritdoc />
    ApiPlcReadRequest IWebApiPrimitive.PeekPlcReadRequestData => _plcReadRequestData ?? WebApiConnector.CreateReadRequest(Symbol, _webApiConnector.DBName);

    /// <inheritdoc />
    ApiPlcWriteRequest IWebApiPrimitive.PeekPlcWriteRequestData => _plcWriteRequestData ?? WebApiConnector.CreateWriteRequest(Symbol, CyclicToWrite, _webApiConnector.DBName);
    
    /// <inheritdoc />
    ApiPlcReadRequest IWebApiPrimitive.PlcReadRequestData
    {
        get
        {
            _plcReadRequestData = WebApiConnector.CreateReadRequest(Symbol, _webApiConnector.DBName);
            return _plcReadRequestData;
        }

    }

    /// <inheritdoc />
    ApiPlcWriteRequest IWebApiPrimitive.PlcWriteRequestData
    {
        get
        {
            _plcWriteRequestData = WebApiConnector.CreateWriteRequest(Symbol, CyclicToWrite, _webApiConnector.DBName);
            return _plcWriteRequestData;
        }
    }

    /// <inheritdoc />
    public void Read(string result)
    {
        UpdateRead(double.Parse(result));
    }

    /// <inheritdoc />
    public override async Task<double> GetAsync()
    {
        return await _webApiConnector.ReadAsync(this, LastValue);
    }

    /// <inheritdoc />
    public override async Task<double> SetAsync(double value)
    {
        return await _webApiConnector.WriteAsync(this, value);
    }
}