﻿////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace Microsoft.VisualStudio.Language.Intellisense
{
    /// <summary>
    /// Defines a custom IntelliSense presenter.
    /// </summary>
    public interface ICustomIntellisensePresenter : IIntellisensePresenter
    {
        /// <summary>
        /// Renders the IntelliSense session.
        /// </summary>
        void Render ( );
    }
}
