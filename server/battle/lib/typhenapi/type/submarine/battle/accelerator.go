// This file was generated by typhen-api

package battle

import (
	"errors"
	"github.com/shiwano/submarine/server/battle/lib/typhenapi/core"
)

var _ = errors.New

// Accelerator is a kind of TyphenAPI type.
type Accelerator struct {
	MaxSpeed       float64 `codec:"max_speed"`
	Duration       int64   `codec:"duration"`
	StartRate      float64 `codec:"start_rate"`
	IsAccelerating bool    `codec:"is_accelerating"`
}

// Coerce the fields.
func (t *Accelerator) Coerce() error {
	return nil
}

// Bytes creates the byte array.
func (t *Accelerator) Bytes(serializer typhenapi.Serializer) ([]byte, error) {
	if err := t.Coerce(); err != nil {
		return nil, err
	}

	data, err := serializer.Serialize(t)
	if err != nil {
		return nil, err
	}

	return data, nil
}
