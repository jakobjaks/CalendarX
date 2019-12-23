import {IBaseEntity} from "./IBaseEntity";

export interface IIdUnit extends IBaseEntity {
  hex: string;
  description: string;
}
