import { Component, OnInit } from "@angular/core";
import { DriverContextService } from "src/app/services/drivercontext.service";
import { TaxiContextService } from "src/app/services/taxicontext.service";

import { Driver, Taxi, VehicleType } from "src/app/services/types.services";

@Component({
  selector: "transport",
  templateUrl: "./taxi.component.html",
  styles: [],
})
export class TaxiComponent implements OnInit {
  drivers: Driver[] = [];
  taxis: Taxi[] = [];
  taxi: Taxi = <Taxi>{};
  isEditing: boolean = false;
  VehicleType = VehicleType;

  constructor(
    private taxiService: TaxiContextService,
    private driverService: DriverContextService
  ) {}

  ngOnInit(): void {
    this.getTaxis();
    this.getDrivers();
  }

  getTaxis(): void {
    this.taxiService.getTaxi().subscribe((results) => (this.taxis = results));
  }

  getDrivers(): void {
    this.driverService
      .getDrivers()
      .subscribe((drivers) => (this.drivers = drivers));
  }

  getTaxi(id: string): void {
    this.isEditing = true;
    this.taxiService.getTaxiById(id).subscribe((result) => {
      this.taxi = <Taxi>result;
    });
  }

  saveChanges(): void {
    this.isEditing ? this.edit() : this.add();
  }

  add(): void {
    this.taxiService.addTaxi(this.taxi).subscribe((result) => {
      this.taxis.push(result);
      this.getTaxis();
    });
    this.clear();
  }

  delete(id: string): void {
    this.taxis = this.taxis.filter((t) => t.id !== id);
    this.taxiService.deleteTaxi(id).subscribe();
  }

  clear(): void {
    this.taxi = <Taxi>{};
  }

  edit() {
    console.log(this.taxi.driver);
    console.log(this.drivers);
    this.taxiService.updateTaxi(this.taxi).subscribe(() => this.getTaxis());
  }
}
