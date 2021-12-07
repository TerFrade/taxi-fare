import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { DriverComponent } from "./components/driver/driver.component";
import { HistoryComponent } from "./components/history/history.component";
import { HomeComponent } from "./components/home/home.component";
import { TransportComponent } from "./components/transport/transport.component";

@NgModule({
  imports: [
    RouterModule.forRoot(
      [
        { path: "Home", component: HomeComponent },
        { path: "Drivers", component: DriverComponent },
        { path: "Transports", component: TransportComponent },
        { path: "History", component: HistoryComponent },
        { path: "**", redirectTo: "/Home", pathMatch: "full" },
      ],
      { relativeLinkResolution: "legacy" }
    ),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
