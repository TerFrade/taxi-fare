//Main Imports
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app-routing.module";
import { HttpClientModule } from "@angular/common/http";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

//Service Imports
import { DriverContextService } from "./services/drivercontext.service";
import { VehicleContextService } from "./services/vehiclecontext.service";

//Components
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
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
  ],
  providers: [DriverContextService, VehicleContextService],
  bootstrap: [AppComponent],
})
export class AppModule {}
