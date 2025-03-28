﻿using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using WorkoutPlanner.DataObject;
using WorkoutPlanner.Tools;
using WorkoutPlanner.Tools.Services;

namespace WorkoutPlanner.Components.Pages.Plan.WorkoutBuilder
{
    partial class WorkoutListView : ComponentBase
    {
        #region Variables
        [Inject]
        public FirestoreService FirestoreService { get; set; }
        [Parameter]
        [NotNull]
        public ProgramPhase Phase { get; set; }
        [Parameter]
        public EventCallback OnWorkoutChange { get; set; }
        [Parameter]
        public EventCallback<Workout> OnWorkoutSelected { get; set; }
        private bool Initialised { get; set; } = false;
        #endregion

        #region Loading
        protected override async Task OnInitializedAsync()
        {
            Initialised = true;

            await base.OnInitializedAsync();
        }

        protected async Task OnWorkoutChanged()
        {
            await OnWorkoutChange.InvokeAsync();
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async Task OnWorkoutClick(Workout workout)
        {
            await OnWorkoutSelected.InvokeAsync(workout);
            await InvokeAsync(() => { StateHasChanged(); });
        }
        #endregion
    }
}
