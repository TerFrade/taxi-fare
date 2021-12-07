import { Component, OnInit } from "@angular/core";
import { DriverContextService } from "src/app/services/drivercontext.service";
import { Driver } from "src/app/services/types.services";

@Component({
  selector: "driver",
  templateUrl: "./driver.component.html",
  styles: [],
})
export class DriverComponent implements OnInit {
  drivers: Driver[] = [];
  constructor(private driverService: DriverContextService) {}

  ngOnInit(): void {
    this.getDrivers();
  }

  getDrivers(): void {
    this.driverService
      .getDrivers()
      .subscribe((drivers) => (this.drivers = drivers));
  }
}
