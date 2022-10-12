import { Injectable } from '@angular/core';
import { IceCream } from '../models/ice-cream';

@Injectable({
  providedIn: 'root',
})
export class IceCreamService {
  constructor() {}

  public getIceCreams(): IceCream[] {
    const iceCream = new IceCream();

    iceCream.id = 1;
    iceCream.name = 'Gelato';
    iceCream.image = '/assets/images/icecream1.png';
    iceCream.brand = 'Cone';
    iceCream.price = 2;
    iceCream.description =
      'A dense ice cream generally made with more milk than cream (making it lower in fat), egg yolks, sugar or other sweeteners and flavourings. Gelato has a more intense flavour than traditional ice cream and less air.';
    iceCream.flavour = 'Cookies and Cream';
    iceCream.place = 'New England';

    return [iceCream];
  }
}
