//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//  Licensed under the MIT License. See License.txt in the project root for license information.
//

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis.Completion;
using Microsoft.CodeAnalysis.Editor;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;

namespace Microsoft.VisualStudio.Platform
{
    internal class RoslynCompletionPresenterSession : ICompletionPresenterSession
    {
        private ITextView _textView;
        private ITextBuffer _subjectBuffer;

        public RoslynCompletionPresenterSession (ITextView textView, ITextBuffer subjectBuffer)
        {
            _textView = textView;
            _subjectBuffer = subjectBuffer;
        }

        public event EventHandler<CompletionItemEventArgs> ItemSelected;
        public event EventHandler<CompletionItemEventArgs> ItemCommitted;
        public event EventHandler<CompletionItemFilterStateChangedEventArgs> FilterStateChanged;
        public event EventHandler<EventArgs> Dismissed;

        public void Dismiss ()
        {
        }

        public void PresentItems (ITrackingSpan triggerSpan, IList<CompletionItem> items, CompletionItem selectedItem, CompletionItem suggestionModeItem, bool suggestionMode, bool isSoftSelected, ImmutableArray<CompletionItemFilter> completionItemFilters, string filterText)
        {
        }

        public void SelectNextItem ()
        {
        }

        public void SelectNextPageItem ()
        {
        }

        public void SelectPreviousItem ()
        {
        }

        public void SelectPreviousPageItem ()
        {
        }
    }
}