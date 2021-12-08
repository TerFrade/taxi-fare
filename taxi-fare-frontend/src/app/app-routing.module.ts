import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { DriverComponent } from "./components/driver/driver.component";
import { HistoryComponent } from "./components/history/history.component";
import { HomeComponent } from "./components/home/home.component";
import { TaxiComponent } from "./components/taxi/taxi.component";
import { TransportComponent } from "./components/transport/transport.component";

@NgModule({
  imports: [
    RouterModule.forRoot(
      [
        { path: "Home", component: HomeComponent },
        { path: "Drivers", component: DriverComponent },
        {
          path: "Transports",
          children: [{ path: "Taxi", component: TaxiComponent }],
        },
        { path: "History", component: HistoryComponent },
        { path: "**", redirectTo: "/Home", pathMatch: "full" },
      ],
      { relativeLinkResolution: "legacy" }
    ),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
