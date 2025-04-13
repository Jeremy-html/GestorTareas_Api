import { BrowserModule, HammerModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';  // Asegúrate de agregar esta importación
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IgxDialogModule, IgxButtonModule, IgxGridModule, IgxAvatarModule, IgxIconModule,
  IgxNavbarModule, IgxDividerModule, IgxTabsModule, IgxToastModule, IgxMaskModule,
  IgxInputGroupModule, IgxButtonGroupModule, IgxSwitchModule, IgxCardModule, IgxListModule, IgxFilterModule } from 'igniteui-angular';
import { TasksDataService } from './services/tasks.service';
import { TaskPlannerComponent } from './taskplanner/taskplanner.component';
import { FormsModule } from '@angular/forms';
import { HeaderComponent } from './header/header.component';
import { BacklogComponent } from './backlog/backlog.component';
import { GridWithTransactionsComponent } from './transaction-component/transaction-grid.component';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { AppComponent } from './app/app.component';

@NgModule({
  declarations: [
    TaskPlannerComponent,
    HeaderComponent,
    BacklogComponent,
    GridWithTransactionsComponent,
    LoginRegisterComponent,
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    IgxDialogModule,
    IgxButtonModule,
    IgxGridModule,
    IgxMaskModule,
    IgxToastModule,
    IgxAvatarModule,
    IgxIconModule,
    IgxFilterModule,
    IgxNavbarModule,
    IgxDividerModule,
    IgxTabsModule,
    IgxToastModule,
    FormsModule,
    IgxMaskModule,
    IgxInputGroupModule,
    IgxButtonGroupModule,
    IgxSwitchModule,
    IgxCardModule,
    IgxListModule,
    HammerModule,                                               
    ReactiveFormsModule   // Aquí es donde agregamos ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
