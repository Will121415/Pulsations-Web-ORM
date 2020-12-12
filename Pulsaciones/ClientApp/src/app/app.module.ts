import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PersonaConsultaComponent } from './Pulsacion/persona-consulta/persona-consulta.component';
import { PersonaRegistroComponent } from './Pulsacion/persona-registro/persona-registro.component';
import { AppRoutingModule } from './app-routing.module';
import { PersonaService } from './services/persona.service';
import { FooterComponent } from './footer/footer.component';
import { FilterPersonPipe } from './pipe/filter-person.pipe';
import { SignalRService } from './services/signal-r.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FooterComponent,
    PersonaConsultaComponent,
    PersonaRegistroComponent,
    FooterComponent,
    FilterPersonPipe,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [PersonaService, SignalRService],
  bootstrap: [AppComponent]
})
export class AppModule { }
