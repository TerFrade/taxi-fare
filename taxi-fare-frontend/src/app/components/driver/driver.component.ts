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
  driver: Driver = <Driver>{};
  isEditing: boolean = false;

  constructor(private driverService: DriverContextService) {}

  ngOnInit(): void {
    this.getDrivers();
  }

  getDrivers(): void {
    this.driverService
      .getDrivers()
      .subscribe((drivers) => (this.drivers = drivers));
  }

  getDriver(id: string): void {
    this.isEditing = true;
    this.driverService.getDriverById(id).subscribe((result) => {
      this.driver = <Driver>result;
    });
  }

  saveChanges(): void {
    this.isEditing ? this.edit() : this.add();
  }

  add(): void {
    this.driverService
      .addDriver(this.driver)
      .subscribe((driver) => this.drivers.push(driver));
    this.clear();
  }

  delete(id: string): void {
    this.drivers = this.drivers.filter((d) => d.id !== id);
    this.driverService.deleteDriver(id).subscribe();
  }

  clear(): void {
    this.driver = <Driver>{};
  }

  edit() {
    this.driverService
      .updateDriver(this.driver)
      .subscribe((driver) => this.getDrivers());
  }
}
