import { Component, OnInit } from "@angular/core";
import { TaxiContextService } from "src/app/services/taxicontext.service";
import { Taxi, VehicleType } from "src/app/services/types.services";

@Component({
  selector: "transport",
  templateUrl: "./taxi.component.html",
  styles: [],
})
export class TaxiComponent implements OnInit {
  taxis: Taxi[] = [];
  taxi: Taxi = <Taxi>{};
  isEditing: boolean = false;
  VehicleType = VehicleType;

  constructor(private taxiService: TaxiContextService) {}

  ngOnInit(): void {
    this.getTaxis();
  }

  getTaxis(): void {
    this.taxiService.getTaxi().subscribe((results) => (this.taxis = results));
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
    this.taxi.drivers = [];
    this.taxiService
      .addTaxi(this.taxi)
      .subscribe((result) => this.taxis.push(result));
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
    this.taxiService.updateTaxi(this.taxi).subscribe(() => this.getTaxis());
  }
}
