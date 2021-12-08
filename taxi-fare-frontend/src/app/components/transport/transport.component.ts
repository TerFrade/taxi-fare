import { Component, OnInit } from "@angular/core";
import { Vehicle, VehicleType } from "src/app/services/types.services";
import { VehicleContextService } from "src/app/services/vehiclecontext.service";

@Component({
  selector: "transport",
  templateUrl: "./transport.component.html",
  styles: [],
})
export class TransportComponent implements OnInit {
  vehicles: Vehicle[] = [];
  vehicle: Vehicle = <Vehicle>{};
  isEditing: boolean = false;
  VehicleType = VehicleType;

  constructor(private vehicleService: VehicleContextService) {}

  ngOnInit(): void {
    this.getDrivers();
  }

  getDrivers(): void {
    this.vehicleService
      .getVehicles()
      .subscribe((vehicles) => (this.vehicles = vehicles));
  }

  getDriver(id: string): void {
    this.isEditing = true;
    this.vehicleService.getVehicleById(id).subscribe((result) => {
      this.vehicle = <Vehicle>result;
    });
  }

  saveChanges(): void {
    this.isEditing ? this.edit() : this.add();
  }

  add(): void {
    this.vehicleService
      .addVehicle(this.vehicle)
      .subscribe((vehicle) => this.vehicles.push(vehicle));
    this.clear();
  }

  delete(id: string): void {
    this.vehicles = this.vehicles.filter((v) => v.id !== id);
    this.vehicleService.deleteVehicle(id).subscribe();
  }

  clear(): void {
    this.vehicle = <Vehicle>{};
  }

  edit() {
    this.vehicleService
      .updateVehicle(this.vehicle)
      .subscribe(() => this.getDrivers());
  }
}
