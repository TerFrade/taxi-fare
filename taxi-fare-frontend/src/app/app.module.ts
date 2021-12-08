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
import { TaxiContextService } from "./services/taxicontext.service";

//Components
import { AppComponent } from "./app.component";
import { HomeComponent } from "./components/home/home.component";
import { NavbarComponent } from "./components/navbar/navbar.component";
import { DriverComponent } from "./components/driver/driver.component";
import { HistoryComponent } from "./components/history/history.component";
import { TaxiComponent } from "./components/taxi/taxi.component";
import { CalculateFareComponent } from "./components/calculate-fare/calculate-fare.component";

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    DriverComponent,
    HistoryComponent,
    TaxiComponent,
    CalculateFareComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
  ],
  providers: [DriverContextService, VehicleContextService, TaxiContextService],
  bootstrap: [AppComponent],
})
export class AppModule {}
