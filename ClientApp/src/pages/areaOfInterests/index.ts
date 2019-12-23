import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IAreaOfInterest} from "../../interfaces/IAreaOfInterest";
import {AreaOfInterestService} from "../../services/areaofinterests-service";
import {BaseService} from "../../services/base-service";

export var log = LogManager.getLogger('AreaOfInterests.Index');

// automatically inject dependencies declared as private constructor parameters
// will be accessible as this.<variablename> in class
@autoinject
export class Index {

  private AreaOfInterests: IAreaOfInterest[] = [];

  constructor(
    private AreaOfInterestsService: AreaOfInterestService
  ) {
    log.debug('constructor');
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
    this.AreaOfInterestsService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.AreaOfInterests = jsonData;
      }
    );
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
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
