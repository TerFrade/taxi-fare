import { Component, OnInit } from "@angular/core";
import { TaxiContextService } from "src/app/services/taxicontext.service";
import { Taxi, VehicleType } from "src/app/services/types.services";

@Component({
  selector: "calculate-fare",
  templateUrl: "./calculate-fare.component.html",
  styles: [],
})
export class CalculateFareComponent implements OnInit {
  transportChoice: string | null = null;
  fileToUpload: File | null = null;
  fareInfo: number[] = [];
  taxis: Taxi[] = [];
  taxisWithPrice: any = [];
  VehicleType = VehicleType;

  constructor(private taxiService: TaxiContextService) {}

  ngOnInit(): void {}

  handleFileInput(event: any) {
    this.fileToUpload = event.target.files[0];
    this.fileToUpload?.text().then((results) => {
      this.fareInfo = results.split(",").map(Number);
    });
  }

  calculateFare(): void {
    if (this.fileToUpload == null) {
      alert("Select a file");
      return;
    }
    switch (this.transportChoice) {
      case "Taxi":
        this.taxiFare();
        break;
      default:
        alert("Select a transport");
    }
  }

  taxiFare(): void {
    this.taxisWithPrice = [];
    this.taxiService.getTaxi().subscribe((results) => {
      this.taxis = results.filter((t) => t.driver !== null);
      this.taxis.forEach((taxi) => {
        if (taxi.baseFareDistance >= this.fareInfo[0]) {
          this.taxisWithPrice.push([taxi, taxi.baseFarePrice]);
        } else {
          const distanceTravled: number =
            this.fareInfo[0] - taxi.baseFareDistance;
          const unitsTraveled: number = distanceTravled / this.fareInfo[1];
          const price: number = Math.round(
            this.fareInfo[0] + unitsTraveled * this.fareInfo[2]
          );
          this.taxisWithPrice.push([taxi, price]);
        }
      });
      this.taxisWithPrice.sort((a: any, b: any) => {
        return a[1] - b[1];
      });
    });
  }
}
