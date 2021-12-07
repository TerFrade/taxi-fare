import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app-routing.module";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./components/home/home.component";
import { NavbarComponent } from "./components/navbar/navbar.component";
import { DriverComponent } from "./components/driver/driver.component";
import { TransportComponent } from "./components/transport/transport.component";
import { HistoryComponent } from "./components/history/history.component";
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    DriverComponent,
    TransportComponent,
    HistoryComponent,
  ],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
