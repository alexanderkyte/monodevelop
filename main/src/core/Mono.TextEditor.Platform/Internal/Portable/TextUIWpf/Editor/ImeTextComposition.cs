// Copyright (c) Microsoft Corporation
// All rights reserved

namespace Microsoft.VisualStudio.Text.Editor
{
    using System.Windows.Input;
    using System.Windows;

    /// <summary>
    /// Represents a text composition generated by the IME processing of the <see cref="ITextView"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="ITextView"/> does its own handling and raises the appropriate
    /// TextComposition events. The TextCompositionEventArgs.TextComposition property
    /// of all events raised by the IME handling can be cast
    /// to <see cref="ImeTextComposition"/>.
    /// </remarks>
    public class ImeTextComposition : TextComposition
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ImeTextComposition"/>.
        /// </summary>
        /// <param name="inputManager">The <see cref="InputManager"/>.</param>
        /// <param name="source">The input element.</param>
        /// <param name="resultText">The text.</param>
        public ImeTextComposition(InputManager inputManager, IInputElement source, string resultText)
            : base(inputManager, source, resultText)
        {
        }
    }
}