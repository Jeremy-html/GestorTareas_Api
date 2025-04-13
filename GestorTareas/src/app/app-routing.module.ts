import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TaskPlannerComponent } from './taskplanner/taskplanner.component';
import { LoginRegisterComponent } from './login-register/login-register.component';

const routes: Routes = [
  { path: '', redirectTo: "/login-register", pathMatch: 'full' }, 
  { path: 'login-register', component: LoginRegisterComponent,
  
  },  
  { path: 'taskplanner', component: TaskPlannerComponent },  // Ruta para el componente principal

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {
}
