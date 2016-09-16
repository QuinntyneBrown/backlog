import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from '@angular/router';

const declarables = [];
const providers = [];

@NgModule({
    imports: [CommonModule, ReactiveFormsModule, RouterModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class ComponentsModule { }
