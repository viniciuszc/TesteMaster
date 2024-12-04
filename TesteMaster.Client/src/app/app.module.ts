import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes} from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ViagemComponent } from './viagem/viagem.component';


const routes: Routes = [
  { path: '', component: ViagemComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ViagemComponent
  ],
  imports: [
    BrowserModule,
      RouterModule.forRoot(routes),
    FormsModule
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
