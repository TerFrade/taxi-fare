export interface Driver {
  id: string;
  name: string;
  surname: string;
  email: string;
  vehicleId: string;
}

export interface Vehicle {
  id: string;
  vehicleType: VehicleType;
  driver: Driver;
}

export interface Taxi extends Vehicle {
  baseFarePrice: number;
  baseFareDistance: number;
}

export enum VehicleType {
  Taxi,
  Bus,
  Train,
}
