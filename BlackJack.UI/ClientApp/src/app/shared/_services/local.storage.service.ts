import { Injectable } from '@angular/core';
import { createDirectiveInstance } from '@angular/core/src/view/provider';

@Injectable({
  providedIn: 'root'
})

export class LocalStorageService {
  constructor() { }

  public clear() {
    localStorage.clear();
  }

  public removeItem(key: string) {
    localStorage.removeItem(key);
  }

  public setItem<T>(key: string, data: T) {
    try {
      const dataAsString: string = (typeof data === "string") ? data : JSON.stringify(data);
      localStorage.setItem(key, dataAsString);
    }
    catch (e) {
      console.log('Error getting data from localStorage', e);
    }
  }

  public getItem<T=string>(key: string): T {
    try {
      const dataAsString = localStorage.getItem(key);
      return JSON.parse(dataAsString);         
    } catch (e) {
      console.log('Error getting data from localStorage', e);
      return null;
    }
  }
}