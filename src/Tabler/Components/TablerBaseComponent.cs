﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TabBlazor;

namespace TabBlazor.Components
{
    public abstract class TablerBaseComponent : ComponentBase
    {
        [Parameter] public TablerColor TextColor { get; set; } = TablerColor.Default;
        [Parameter] public TablerColor BackgroundColor { get; set; } = TablerColor.Default;
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> UnmatchedParameters { get; set; }

        protected ClassBuilder ClassBuilder => new ClassBuilder(GetUnmatchedParameter("Class")?.ToString());

        protected virtual string ClassNames => ClassBuilder.ToString();

        protected object GetUnmatchedParameter(string key)
        {
            if (UnmatchedParameters?.ContainsKey(key) ?? false)
            {
                var value = UnmatchedParameters[key];
                UnmatchedParameters.Remove(key);
                return value;
            }

            return null;
        }
    }
}