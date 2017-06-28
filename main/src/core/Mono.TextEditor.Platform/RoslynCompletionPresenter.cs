//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//  Licensed under the MIT License. See License.txt in the project root for license information.
//

using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis.Editor;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace Microsoft.VisualStudio.Platform
{
    [Export (typeof (IIntelliSensePresenter<ICompletionPresenterSession, ICompletionSession>))]
    [Name (PredefinedCompletionPresenterNames.RoslynCompletionPresenter)]
    [ContentType (ContentTypeNames.RoslynContentType)]
    internal sealed class RoslynCompletionPresenter : IIntelliSensePresenter<ICompletionPresenterSession, ICompletionSession>
    {
        public ICompletionPresenterSession CreateSession (ITextView textView, ITextBuffer subjectBuffer, ICompletionSession sessionOpt)
        {
            return new RoslynCompletionPresenterSession (textView, subjectBuffer);
        }
    }
}