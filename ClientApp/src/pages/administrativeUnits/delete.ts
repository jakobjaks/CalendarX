import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {AdministrativeUnitService} from "../../services/administrativeunit-service";
import {IAdministrativeUnit} from "../../interfaces/IAdministrativeUnit";

export var log = LogManager.getLogger('AdministrativeUnit.Delete');

@autoinject
export class Delete {

  private administrativeUnit: IAdministrativeUnit;

  constructor(
    private router: Router,
    private administrativeUnitService: AdministrativeUnitService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.administrativeUnitService.delete(this.administrativeUnit.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("AdministrativeUnitsIndex");
      } else {
        log.debug('response', response);
      }
    });
  }

  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');

  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate', params);
    this.administrativeUnitService.fetch(params.id).then(
      administrativeUnit => {
        log.debug('administrativeunit', administrativeUnit);
        this.administrativeUnit = administrativeUnit;
      }
    );

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
