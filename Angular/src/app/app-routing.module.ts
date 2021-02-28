import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { EmployeeDirectoryComponent } from "./employee-directory/employee-directory.component";
import { EmployeeFormComponent } from "./employee-form/employee-form.component";
import { LoginComponent } from "./login/login.component";

const appRoutes: Routes = [
    {path: '', redirectTo: '/login', pathMatch: 'full'},
    {path: 'login', component: LoginComponent},
    {path: 'directory', component: EmployeeDirectoryComponent},
    {path: 'add', component: EmployeeFormComponent}
]

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}